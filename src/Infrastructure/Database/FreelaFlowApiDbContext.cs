using FreelaFlowApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace FreelaFlowApi.Infrastructure.Database;
public class FreelaFlowApiDbContext(DbContextOptions<FreelaFlowApiDbContext> options) : DbContext(options)
{
    public DbSet<ClientBillingEntity> ClientBillings => Set<ClientBillingEntity>();
    public DbSet<ClientClientLabelEntity> ClientClientLabels => Set<ClientClientLabelEntity>();
    public DbSet<ClientEntity> Clients => Set<ClientEntity>();
    public DbSet<ClientLabelEntity> ClientLabels => Set<ClientLabelEntity>();
    public DbSet<InvoiceEntity> Invoices => Set<InvoiceEntity>();
    public DbSet<ProjectEntity> Projects => Set<ProjectEntity>();
    public DbSet<ProjectLabelEntity> ProjectLabels => Set<ProjectLabelEntity>();
    public DbSet<ProjectProjectLabelEntity> ProjectProjectLabels => Set<ProjectProjectLabelEntity>();
    public DbSet<ProjectServiceEntity> ProjectServices => Set<ProjectServiceEntity>();
    public DbSet<ReceiptEntity> Receipts => Set<ReceiptEntity>();
    public DbSet<ServiceEntity> Services => Set<ServiceEntity>();
    public DbSet<TaskEntity> Tasks => Set<TaskEntity>();
    public DbSet<TaskLabelEntity> TaskLabels => Set<TaskLabelEntity>();
    public DbSet<TaskTaskLabelEntity> TaskTaskLabels => Set<TaskTaskLabelEntity>();
    public DbSet<TaskTemplateEntity> TaskTemplates => Set<TaskTemplateEntity>();
    public DbSet<TaskTemplateTaskLabelEntity> TaskTemplateTaskLabels => Set<TaskTemplateTaskLabelEntity>();
    public DbSet<UserBillingEntity> UserBillings => Set<UserBillingEntity>();
    public DbSet<UserEntity> Users => Set<UserEntity>();
    public DbSet<WorkingHoursEntity> WorkingHourses => Set<WorkingHoursEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}