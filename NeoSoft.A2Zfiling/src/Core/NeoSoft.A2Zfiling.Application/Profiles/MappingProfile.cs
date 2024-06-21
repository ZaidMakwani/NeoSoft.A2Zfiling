using AutoMapper;
using NeoSoft.A2Zfiling.Application.Features.Login.Command;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.CreateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.DeleteCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Command.UpdateCity;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityById;
using NeoSoft.A2Zfiling.Application.Features.Cities.Queries.GetCityList;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.CreatePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.DeletePermission;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Command.UpdatePermisssion;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionById;
using NeoSoft.A2Zfiling.Application.Features.Permissionsss.Queries.GetPermissionList;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.CreateUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.DeleteUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Command.UpdateUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermission;
using NeoSoft.A2Zfiling.Application.Features.UserPermissionsss.Queries.GetUserPermissionById;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.CreateZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.DeleteZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Commands.UpdateZone;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneList;
using NeoSoft.A2Zfiling.Application.Features.Zoneies.Queries.GetZoneListWithEvent;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.CreateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.DeleteIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Commands.UpdateIndustry;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustriesList;
using NeoSoft.A2Zfiling.Application.Features.IndustriesFeature.Queries.GetIndustryById;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Commands.CreateMunicipal;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalDetails;
using NeoSoft.A2Zfiling.Application.Features.MunicipalCorporation.Queries.GetMunicipalList;
using NeoSoft.A2Zfiling.Application.Features.Register.Command;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.CreateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateMunicipal;
using NeoSoft.A2Zfiling.Application.Features.Roles.Commands.UpdateRoles;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRoleaDetails;
using NeoSoft.A2Zfiling.Application.Features.Roles.Queries.GetRolesList;

using NeoSoft.A2Zfiling.Application.Features.Categories.Commands.CreateState;

using NeoSoft.A2Zfiling.Application.Features.Documents.CreateDocument;

using NeoSoft.A2Zfiling.Application.Features.Login;

using NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.DeletePinCode;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Commands.UpdatePinCode;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPicodeList;
using NeoSoft.A2Zfiling.Application.Features.Pincodes.Queries.GetPinCode;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.CreateState;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.DeleteState;
using NeoSoft.A2Zfiling.Application.Features.States.Commands.UpdateState;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateById;
using NeoSoft.A2Zfiling.Application.Features.States.Queries.GetStateList;
using NeoSoft.A2Zfiling.Domain.Entities;
using System.Security.Principal;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.CreateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.UpdateCompany;
using NeoSoft.A2Zfiling.Application.Features.CompaniesFeature.Commands.DeleteCompany;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.CreateLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeList;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Queries.GetLicenseTypeById;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.UpdateLicenseType;
using NeoSoft.A2Zfiling.Application.Features.LicenseTypes.Command.DeleteLicenseType;
using NeoSoft.A2Zfiling.Application.Features.Categories.Command.CreateCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoryList;
using NeoSoft.A2Zfiling.Application.Features.Categories.Queries.GetCategoryById;
using NeoSoft.A2Zfiling.Application.Features.Categories.Command.DeleteCategory;
using NeoSoft.A2Zfiling.Application.Features.Categories.Command.UpdateCategory;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.CreateLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseList;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Queries.LicenseListByid;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.DeleteLicense;
using NeoSoft.A2Zfiling.Application.Features.Licenses.Command.UpdateLicense;

using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.CreateStatus;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Queries.StatusList;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Queries.StatusListById;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.UpdateStatus;
using NeoSoft.A2Zfiling.Application.Features.Stuatuses.Command.DeleteStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.CreateSubStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusList;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Queries.SubStatusListById;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.UpdateSubStatus;
using NeoSoft.A2Zfiling.Application.Features.SubStatuses.Command.DeleteSubStatus;

using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Queries;
using NeoSoft.A2Zfiling.Application.Features.MyProfileFeature.Commands;
using NeoSoft.A2Zfiling.Application.Features.UserInfo.Queries;



namespace NeoSoft.A2Zfiling.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Zones, CreateZoneDto>().ReverseMap();
            CreateMap<Zones, CreateZoneCommand>().ReverseMap();
            CreateMap<Zones, GetZoneListDto>().ReverseMap();
            CreateMap<Zones, DeleteZoneDto>().ReverseMap();
            CreateMap<Zones, UpdateZoneDto>().ReverseMap();
            CreateMap<Zones, UpdateZoneCommand>().ReverseMap();
            CreateMap<Zones, GetEventByIdDto>().ReverseMap();

            CreateMap<City, CreateCityDto>().ReverseMap();
            CreateMap<City, GetCityListDto>().ReverseMap();
            CreateMap<City, UpdateCityDto>().ReverseMap();
            CreateMap<City, UpdateCityCommand>().ReverseMap();
            CreateMap<City, DeleteCityDto>().ReverseMap();
            CreateMap<City, GetCityByIdDto>().ReverseMap();
            CreateMap<City, GetCityByIdCommand>().ReverseMap();

            CreateMap<Permission, CreatePermissionDto>().ReverseMap();
            CreateMap<Permission, CreatePermisssionCommand>().ReverseMap();
            CreateMap<Permission, GetPermissionListDto>().ReverseMap();
            CreateMap<Permission, GetPermissionByIdDto>().ReverseMap();
            CreateMap<Permission, UpdatePermissionCommand>().ReverseMap();
            CreateMap<Permission, UpdatePermissionDto>().ReverseMap();
            CreateMap<Permission, DeletePermissionDto>().ReverseMap();





            CreateMap<Industry, CreateIndustryDto>().ReverseMap();
            CreateMap<Industry, IndustryListVM>().ReverseMap();
            CreateMap<Industry, IndustryListSingleVM>().ReverseMap();
            CreateMap<Industry, UpdateIndustryDto>().ReverseMap();
            CreateMap<Industry, UpdateIndustryCommand>().ReverseMap();
            CreateMap<Industry, DeleteIndustryDto>().ReverseMap();

            CreateMap<Company, CreateCompanyDto>().ReverseMap();
            CreateMap<Company, CompanyListVM>().ReverseMap();
            CreateMap<Company, UpdateCompanyDto>().ReverseMap();
            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, DeleteCompanyDto>().ReverseMap();


            CreateMap<AppUser, RegisterDTO>().ReverseMap();



            CreateMap<Document, CreateDocumentDto>().ReverseMap();

            CreateMap<State, CreateStateDto>().ReverseMap();
            CreateMap<State, StateListVm>().ReverseMap();
            CreateMap<State, DeleteStateDto>().ReverseMap();
            CreateMap<State, UpdateStateDto>().ReverseMap();
            CreateMap<State, UpdateStateCommand>().ReverseMap();
            CreateMap<State, StateVM>().ReverseMap();



            CreateMap<PinCode, CreatePinCodeDto>().ReverseMap();
            CreateMap<PinCode, PinCodeListVm>().ReverseMap();
            CreateMap<PinCode, DeletePinCodeDto>().ReverseMap();
            CreateMap<PinCode, UpdatePinCodeDto>().ReverseMap();
            CreateMap<PinCode, UpdatePinCodeCommand>().ReverseMap();
            CreateMap<PinCode, PinCodeVM>().ReverseMap();
            CreateMap<Login, LoginDto>().ReverseMap();

                CreateMap<Role, CreateRolesDto>();
                CreateMap<Role, RolesDto>();
                CreateMap<Role, RolesListVM>();
                CreateMap<Role, UpdateRolesCommand>().ReverseMap();
                CreateMap<Role, GetRoleDto>();
           CreateMap<AppUser, RegisterDTO>();
            CreateMap<AppUser, LoginDto>();
            CreateMap<AppUser, AppUsersDto>().ReverseMap();
            CreateMap<AppUser, UpdateUsersDto>().ReverseMap();

            CreateMap<Role, CreateRolesDto>();
            CreateMap<Role, RolesDto>();
            CreateMap<Role, RolesListVM>();
            CreateMap<Role, UpdateRolesCommand>().ReverseMap();
            CreateMap<Role, GetRoleDto>();

            CreateMap<MunicipalCorp, CreateMunicipalDto>();
            CreateMap<MunicipalCorp, MunicipalListVM>();
            CreateMap<MunicipalCorp, UpdateMunicipalCommand>().ReverseMap();
            CreateMap<MunicipalCorp, MunicipalDto>();
            CreateMap<MunicipalCorp, GetMunicipalDto>();

                CreateMap<UserPermission, CreateUserPermissionDto>().ReverseMap();
                CreateMap<UserPermission, GetUserPermissionDto>().ReverseMap();
                CreateMap<UserPermission, GetUserPermissionByIdDto>().ReverseMap();
                CreateMap<UserPermission, GetUserPermissionCommand>().ReverseMap();
                CreateMap<UserPermission, DeleteUserPermissionDto>().ReverseMap();
                CreateMap<UserPermission, UpdateUserPermissionCommand>().ReverseMap();
                CreateMap<UserPermission, UpdateUserPermissionDto>().ReverseMap();

            CreateMap<LicenseType,CreateLicenseTypeDto>().ReverseMap();
            CreateMap<LicenseType,GetLicenseTypeListDto>().ReverseMap();
            CreateMap<LicenseType,GetLicenseTypeByIdDto>().ReverseMap();
            CreateMap<LicenseType,UpdateLicenseTypeCommand>().ReverseMap();
            CreateMap<LicenseType,UpdateLicenseTypeDto>().ReverseMap();
            CreateMap<LicenseType,DeleteLicenseTypeDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category,GetCategoryListDto>().ReverseMap();
            CreateMap<Category,GetCategoryByIdDto>().ReverseMap();
            CreateMap<Category,DeleteCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();

            CreateMap<License,CreateLicenseDto>().ReverseMap();
            CreateMap<License,LicenseListDto>().ReverseMap();
            CreateMap<License,LicenseListByIdDto>().ReverseMap();
            CreateMap<License,DeleteLicenseDto>().ReverseMap();
            CreateMap<License,UpdateLicenseCommand>().ReverseMap();
            CreateMap<License,UpdateLicenseDto>().ReverseMap();

            CreateMap<Status,CreateStatusDto>().ReverseMap();
            CreateMap<Status,StatusListDto>().ReverseMap();
            CreateMap<Status,StatusListByIdDto>().ReverseMap();
            CreateMap<Status, UpdateStatusCommand>().ReverseMap();
            CreateMap<Status, UpdateStatusDto>().ReverseMap();
            CreateMap<Status,DeleteStatusDto>().ReverseMap();

            CreateMap<SubStatus,CreateSubStatusDto>().ReverseMap();
            CreateMap<SubStatus,SubStatusListDto>().ReverseMap();
            CreateMap<SubStatus, SubStatusListByIdDto>().ReverseMap();
            CreateMap<SubStatus,UpdateSubStatusDto>().ReverseMap();
            CreateMap<SubStatus,UpdateSubStatusCommand>().ReverseMap();
            CreateMap<SubStatus,DeleteSubStatusDto>().ReverseMap();

            CreateMap<AppUser, GetUserIdByEmailDto>().ReverseMap();
        }
    }
}
