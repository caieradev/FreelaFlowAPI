using System.Threading.Tasks;
using FreelaFlowApi.Application.DTOs;
using FreelaFlowApi.Application.Exceptions;
using FreelaFlowApi.Application.Extensions;
using FreelaFlowApi.Application.Interfaces;
using FreelaFlowApi.Domain.Entities;

namespace FreelaFlowApi.Application.Services;
public class ClientService(IHttpContextAccessor httpContextAccessor, IClientRepository clientRepository) : BaseService(httpContextAccessor), IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    public async Task<IEnumerable<ClientItemDTO>> GetAll() =>
        (await _clientRepository.GetAll(GetUserId()))
            .Select(ClientItemDTO.FromEntity);

    public async Task AddBilling(Guid clientId, ClientBillingRequestDTO dto)
    {
        ValidateClientBillingRequestDTO(dto);
        var clientEntity = await GetClientByIdAndValidateAccess(clientId, withBilling: true);
        if (clientEntity.ClientBilling != null) 
            throw new MessageException("Cliente já possui informações de cobrança!");

        await _clientRepository.AddBilling(ClientBillingRequestDTO.ToEntity(dto, clientId));
    }

    public async Task UpdateLabels(Guid id, LabelsDTO labelsDto)
    {
        var clientEntity = await GetClientByIdAndValidateAccess(id, withLabels: true);
        
        var labelsAdd = labelsDto.labels
            .Except(clientEntity.ClientClientLabels
                .Select(x => x.ClientLabelId))
            .Select(x => new ClientClientLabelEntity
            {
                ClientId = id,
                ClientLabelId = x
            });

        var labelIdsToRemove = clientEntity.ClientClientLabels
            .Select(x => x.ClientLabelId)
            .Except(labelsDto.labels);

        await _clientRepository.UpdateLabels(id, labelsAdd, labelIdsToRemove);        
    }

    public async Task<ClientDTO> Create(CreateClientRequestDTO dto)
    {
        ValidateCreateClientDTO(dto);

        var clientEntity = CreateClientRequestDTO.ToEntity(dto, GetUserId());
        return ClientDTO.FromEntity(await _clientRepository.Insert(clientEntity));
    }

    public async Task Delete(Guid id)
    {
        await GetClientByIdAndValidateAccess(id);

        await _clientRepository.Delete(id);
    }

    public async Task<ClientDTO> GetById(Guid id)
    {
        var entity = await GetClientByIdAndValidateAccess(id, complete: true);
        
        return ClientDTO.FromEntity(entity);
    }

    public async Task RemoveBilling(Guid clientId)
    {
        var clientEntity = await GetClientByIdAndValidateAccess(clientId, withBilling: true);
        if (clientEntity.ClientBilling == null)
            throw new MessageException("Cliente não possui informações de cobrança!");

        await _clientRepository.DeleteBilling(clientEntity.ClientBilling.Id);
    }

    public async Task<ClientDTO> Update(Guid id, UpdateClientRequestDTO dto)
    {
        ValidateUpdateClientDTO(id, dto);

        var entity = await GetClientByIdAndValidateAccess(id);

        entity = UpdateClientRequestDTO.UpdateEntity(dto, entity);
        
        return ClientDTO.FromEntity(await _clientRepository.Update(entity));
    }

    public async Task UpdateBilling(Guid clientId, ClientBillingRequestDTO dto)
    {
        ValidateClientBillingRequestDTO(dto);
        var clientEntity = await GetClientByIdAndValidateAccess(clientId, withBilling: true);

        var billingEntity = clientEntity.ClientBilling ??
            throw new DebugMessageException("Informações de cobrança não encontradas!");

        billingEntity = ClientBillingRequestDTO.UpdateEntity(dto, billingEntity);

        await _clientRepository.UpdateBilling(billingEntity);
    }

    private static void ValidateCreateClientDTO(CreateClientRequestDTO dto) =>
        ValidadeClientFields(dto.name, dto.email, dto.phone);

    private static void ValidateUpdateClientDTO(Guid id, UpdateClientRequestDTO dto)
    {
        if (id == Guid.Empty)
            throw new MessageException("Id do cliente é obrigatório!");
        ValidadeClientFields(dto.name, dto.email, dto.phone);
    }

    private static void ValidadeClientFields(string name, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new MessageException("Nome do cliente é obrigatório!");
        if (string.IsNullOrWhiteSpace(email))
            throw new MessageException("Email do cliente é obrigatório!");
        if (!string.IsNullOrWhiteSpace(phone) && !phone.IsValidPhoneNumber())
            throw new MessageException("Telefone do cliente é inválido!");
    }

    private static void ValidateClientBillingRequestDTO(ClientBillingRequestDTO dto)
    {
        if (!string.IsNullOrWhiteSpace(dto.documentNumber) && !dto.documentNumber.IsValidIdDocument())
            throw new MessageException("Número do documento inválido!");
        if (!string.IsNullOrWhiteSpace(dto.state) && dto.state.Length != 2)
            throw new MessageException("Estado inválido!");
        if (!string.IsNullOrWhiteSpace(dto.zipCode) && !dto.zipCode.IsValidZipCode())
            throw new MessageException("CEP inválido!");
    }

    private async Task<ClientEntity> GetClientByIdAndValidateAccess(Guid id, bool complete = false, bool withLabels = false, bool withBilling = false)
    {
        var entity = (complete ? 
            await _clientRepository.GetByIdComplete(id) : 
            await _clientRepository.GetById(id, withLabels, withBilling)) ??
                throw new DebugMessageException("Cliente não encontrado");

        if (entity.UserId != GetUserId())
            throw new MessageException("Você não tem acesso a esse cliente!");
        return entity;
    }

    
}