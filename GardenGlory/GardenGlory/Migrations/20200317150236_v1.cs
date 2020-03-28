using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GardenGlory.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessRestriction",
                columns: table => new
                {
                    RestrictionId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessRestriction", x => x.RestrictionId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeStatus",
                columns: table => new
                {
                    EmployeeStatusId = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatus", x => x.EmployeeStatusId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    EmployeeTypeId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.EmployeeTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<string>(nullable: false),
                    EquipmentName = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLevel",
                columns: table => new
                {
                    ExperienceLevelId = table.Column<string>(nullable: false),
                    Level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevel", x => x.ExperienceLevelId);
                });

            migrationBuilder.CreateTable(
                name: "OwnerType",
                columns: table => new
                {
                    OwnerTypeId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnerType", x => x.OwnerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<string>(nullable: false),
                    Method = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    ServiceTypeId = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<string>(nullable: false),
                    RoleType = table.Column<string>(nullable: true),
                    RestrictionId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                    table.ForeignKey(
                        name: "FK_Role_AccessRestriction_RestrictionId",
                        column: x => x.RestrictionId,
                        principalTable: "AccessRestriction",
                        principalColumn: "RestrictionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentRepair",
                columns: table => new
                {
                    EquipmentRepairId = table.Column<string>(nullable: false),
                    EquipmentId = table.Column<string>(nullable: true),
                    DateOfRepair = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentRepair", x => x.EquipmentRepairId);
                    table.ForeignKey(
                        name: "FK_EquipmentRepair_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(nullable: false),
                    ExperienceLevelId = table.Column<string>(nullable: true),
                    EmployeeStatusId = table.Column<string>(nullable: true),
                    SupervisorId = table.Column<string>(nullable: true),
                    EmployeeTypeId = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    CellPhone = table.Column<string>(nullable: true),
                    TotalHourrsWorked = table.Column<double>(nullable: false, defaultValue: 0.0),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeStatus_EmployeeStatusId",
                        column: x => x.EmployeeStatusId,
                        principalTable: "EmployeeStatus",
                        principalColumn: "EmployeeStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeType",
                        principalColumn: "EmployeeTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_ExperienceLevel_ExperienceLevelId",
                        column: x => x.ExperienceLevelId,
                        principalTable: "ExperienceLevel",
                        principalColumn: "ExperienceLevelId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<string>(nullable: false),
                    OwnerTypeId = table.Column<string>(nullable: true),
                    OwnerName = table.Column<string>(nullable: true),
                    OwnerEmail = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                    table.ForeignKey(
                        name: "FK_Owner_OwnerType_OwnerTypeId",
                        column: x => x.OwnerTypeId,
                        principalTable: "OwnerType",
                        principalColumn: "OwnerTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Account_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainedEmployee",
                columns: table => new
                {
                    TrainedEmployeeId = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    EquipmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainedEmployee", x => x.TrainedEmployeeId);
                    table.ForeignKey(
                        name: "FK_TrainedEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainedEmployee_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    PropertyId = table.Column<string>(nullable: false),
                    ParentPropertyId = table.Column<string>(nullable: true),
                    OwnerId = table.Column<string>(nullable: true),
                    PropertyName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Property_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Property_Property_ParentPropertyId",
                        column: x => x.ParentPropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyDescription",
                columns: table => new
                {
                    PropertyDescriptionId = table.Column<string>(nullable: false),
                    PropertyId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyDescription", x => x.PropertyDescriptionId);
                    table.ForeignKey(
                        name: "FK_PropertyDescription_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<string>(nullable: false),
                    PropertyId = table.Column<string>(nullable: true),
                    ServiceTypeId = table.Column<string>(nullable: true),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    ServiceRequest = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Service_Property_PropertyId",
                        column: x => x.PropertyId,
                        principalTable: "Property",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_ServiceType_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceType",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<string>(nullable: false),
                    ServiceId = table.Column<string>(nullable: true),
                    PaymentMethodId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    TaskId = table.Column<string>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true),
                    ServiceId = table.Column<string>(nullable: true),
                    DateConducted = table.Column<DateTime>(nullable: false),
                    HoursWorked = table.Column<double>(nullable: false),
                    TaskName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Task_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentUsage",
                columns: table => new
                {
                    EquipmentUsageId = table.Column<string>(nullable: false),
                    EquipmentId = table.Column<string>(nullable: true),
                    TaskId = table.Column<string>(nullable: true),
                    UsageDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentUsage", x => x.EquipmentUsageId);
                    table.ForeignKey(
                        name: "FK_EquipmentUsage_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "EquipmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EquipmentUsage_Task_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Task",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_EmployeeId",
                table: "Account",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleId",
                table: "Account",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeStatusId",
                table: "Employee",
                column: "EmployeeStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeTypeId",
                table: "Employee",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ExperienceLevelId",
                table: "Employee",
                column: "ExperienceLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_SupervisorId",
                table: "Employee",
                column: "SupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentRepair_EquipmentId",
                table: "EquipmentRepair",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsage_EquipmentId",
                table: "EquipmentUsage",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentUsage_TaskId",
                table: "EquipmentUsage",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Owner_OwnerTypeId",
                table: "Owner",
                column: "OwnerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodId",
                table: "Payment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ServiceId",
                table: "Payment",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_OwnerId",
                table: "Property",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Property_ParentPropertyId",
                table: "Property",
                column: "ParentPropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyDescription_PropertyId",
                table: "PropertyDescription",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_RestrictionId",
                table: "Role",
                column: "RestrictionId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_PropertyId",
                table: "Service",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceTypeId",
                table: "Service",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_EmployeeId",
                table: "Task",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ServiceId",
                table: "Task",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainedEmployee_EmployeeId",
                table: "TrainedEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainedEmployee_EquipmentId",
                table: "TrainedEmployee",
                column: "EquipmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "EquipmentRepair");

            migrationBuilder.DropTable(
                name: "EquipmentUsage");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PropertyDescription");

            migrationBuilder.DropTable(
                name: "TrainedEmployee");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "AccessRestriction");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "EmployeeStatus");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "ExperienceLevel");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "Owner");

            migrationBuilder.DropTable(
                name: "OwnerType");
        }
    }
}
