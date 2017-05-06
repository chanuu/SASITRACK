using Abp.Application.Navigation;
using Abp.Localization;
using ITrackERP.Authorization;

namespace ITrackERP.Web
{
    /// <summary>
    /// This class defines menus for the application.
    /// It uses ABP's menu system.
    /// When you add menu items here, they are automatically appear in angular application.
    /// See .cshtml and .js files under App/Main/views/layout/header to know how to render menu.
    /// </summary>
    public class ITrackERPNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        "Home",
                        new LocalizableString("HomePage", ITrackERPConsts.LocalizationSourceName),
                        url: "#/",
                        icon: "fa fa-home"
                        )

                )



                  .AddItem(
                    new MenuItemDefinition(
                        "Costing",
                        new LocalizableString("Costing", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        ).AddItem(
                    new MenuItemDefinition(
                      "Styles",
                        new LocalizableString("Styles", ITrackERPConsts.LocalizationSourceName),
                        url: "#/styles",
                        icon: "fa fa-info"
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                         "Buyers",
                        new LocalizableString("Buyers", ITrackERPConsts.LocalizationSourceName),
                        url: "#/buyers",
                        icon: "fa fa-info"
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                        "WorkOrders",
                        new LocalizableString("WorkOrders", ITrackERPConsts.LocalizationSourceName),
                        url: "#/workorders",
                        icon: "fa fa-info"
                        )
                )
                )

              .AddItem(
                    new MenuItemDefinition(
                        "Cutting",
                        new LocalizableString("Cutting", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        )
                        .AddItem(
                    new MenuItemDefinition(
                    "IssueNote",
                        new LocalizableString("IssueNote", ITrackERPConsts.LocalizationSourceName),
                        url: "#/issuenoteheader",
                        icon: "fa fa-info"
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                    "CuttingRatio",
                        new LocalizableString("CuttingRatio", ITrackERPConsts.LocalizationSourceName),
                        url: "#/cuttingratios",
                        icon: "fa fa-info"
                        )
                )

                  .AddItem(
                    new MenuItemDefinition(
                      "DailyPlanHeaders",
                        new LocalizableString("DailyPlanHeaders", ITrackERPConsts.LocalizationSourceName),
                        url: "#/dailyplanheader",
                        icon: "fa fa-info"
                        )
                )

                 .AddItem(
                    new MenuItemDefinition(
                      "CuttingMaster",
                        new LocalizableString("CuttingMaster", ITrackERPConsts.LocalizationSourceName),
                        url: "#/cuttingmasters",
                        icon: "fa fa-info"
                        )
                )
                )
                              //----------------------------------------------------------------------



                              .AddItem(
                    new MenuItemDefinition(
                        "comlianceandsafety",
                        new LocalizableString("comlianceandsafety", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        )


                .AddItem(
                    new MenuItemDefinition(
                       "File",
                        new LocalizableString("File", ITrackERPConsts.LocalizationSourceName),
                        url: "#/file",
                        icon: "fa fa-info"
                        )
                )
                .AddItem(
                    new MenuItemDefinition(
                       "CategorySetUp",
                        new LocalizableString("CategorySetUp", ITrackERPConsts.LocalizationSourceName),
                        url: "#/category",
                        icon: "fa fa-info"
                        )
                )

                )


                              //----------------------------------------------------------------------

                              .AddItem(
                    new MenuItemDefinition(
                        "maintenance",
                        new LocalizableString("maintenance", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        )


                            .AddItem(
                    new MenuItemDefinition(
                       "Items",
                        new LocalizableString("Items", ITrackERPConsts.LocalizationSourceName),
                        url: "#/itemmasters",
                        icon: "fa fa-info"
                        )
                )

                        .AddItem(
                    new MenuItemDefinition(
                       "Jobcards",
                        new LocalizableString("Jobcards", ITrackERPConsts.LocalizationSourceName),
                        url: "#/jobcardheaders",
                        icon: "fa fa-info"
                        )
                )

                        .AddItem(
                    new MenuItemDefinition(
                        "StockRecieve",
                        new LocalizableString("StockRecieve", ITrackERPConsts.LocalizationSourceName),
                        url: "#/stockreceiveheaders",
                        icon: "fa fa-info"
                        )
                )
                )



                              //----------------------------------------------------------------------

                              .AddItem(
                    new MenuItemDefinition(
                        "hr",
                        new LocalizableString("hr", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        )

                        .AddItem(
                    new MenuItemDefinition(
                       "Employees",
                        new LocalizableString("Employees", ITrackERPConsts.LocalizationSourceName),
                        url: "#/employees",
                        icon: "fa fa-info"
                        )
                )
                 .AddItem(
                    new MenuItemDefinition(
                       "EventHeaders",
                        new LocalizableString("EventHeaders", ITrackERPConsts.LocalizationSourceName),
                        url: "#/eventheader",
                        icon: "fa fa-info"
                        )
                )
                )


                              //----------------------------------------------------------------------

                              .AddItem(
                    new MenuItemDefinition(
                        "Assets",
                        new LocalizableString("Assets", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        )

                            .AddItem(
                    new MenuItemDefinition(
                       "TimeLine",
                        new LocalizableString("TimeLine", ITrackERPConsts.LocalizationSourceName),
                        url: "#/timeline",
                        icon: "fa fa-info"
                        )
                )


                   .AddItem(
                    new MenuItemDefinition(
                       "AssetVerification",
                        new LocalizableString("AssetVerification", ITrackERPConsts.LocalizationSourceName),
                        url: "#/assetverification",
                        icon: "fa fa-info"
                        )
                )
                            .AddItem(
                    new MenuItemDefinition(
                       "Assets",
                        new LocalizableString("Assets", ITrackERPConsts.LocalizationSourceName),
                        url: "#/assets",
                        icon: "fa fa-info"
                        )
                )

                    
                        .AddItem(
                    new MenuItemDefinition(
                        "AssetDisposals",
                        new LocalizableString("AssetDisposals", ITrackERPConsts.LocalizationSourceName),
                        url: "#/assetdisposals",
                        icon: "fa fa-info"
                        )
                )



                     .AddItem(
                    new MenuItemDefinition(
                      "RentMachines",
                        new LocalizableString("RentMachines", ITrackERPConsts.LocalizationSourceName),
                        url: "#/rentmachines",
                        icon: "fa fa-info"
                        )
                )


                   .AddItem(
                    new MenuItemDefinition(
                      "AssetTransfers",
                        new LocalizableString("AssetTransfers", ITrackERPConsts.LocalizationSourceName),
                        url: "#/assettransfers",
                        icon: "fa fa-info"
                ))

               
                 .AddItem(
                    new MenuItemDefinition(
                 "MachineRequirements",
                        new LocalizableString("MachineRequirements", ITrackERPConsts.LocalizationSourceName),
                        url: "#/machinerequirements",
                        icon: "fa fa-info"
                        )
                )

                .AddItem(
                    new MenuItemDefinition(
                        "MachineTypes",
                        new LocalizableString("MachineTypes", ITrackERPConsts.LocalizationSourceName),
                        url: "#/machinetypes",
                        icon: "fa fa-info"

                        ))
                )



                     //----------------------------------------------------------------------



                     .AddItem(
                    new MenuItemDefinition(
                        "T/W",
                        new LocalizableString("T/W", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        )
                        .AddItem(
                    new MenuItemDefinition(
                     "OperationPool",
                        new LocalizableString("OperationPool", ITrackERPConsts.LocalizationSourceName),
                        url: "#/operations",
                        icon: "fa fa-info"
                        )
                )

                   
                 .AddItem(
                    new MenuItemDefinition(
                      "DividingPlans",
                        new LocalizableString("DividingPlans", ITrackERPConsts.LocalizationSourceName),
                        url: "#/dividingplans",
                        icon: "fa fa-info"
                        )
                )
                  .AddItem(
                    new MenuItemDefinition(
                        "Elements",
                        new LocalizableString("Elements", ITrackERPConsts.LocalizationSourceName),
                        url: "#/elements",
                        icon: "fa fa-info"

                        ))
                )







               // / departments



                 .AddItem(
                    new MenuItemDefinition(
                        "Settings",
                        new LocalizableString("Settings", ITrackERPConsts.LocalizationSourceName),
                        url: "",
                        icon: "fa fa-info"
                        )
                        .AddItem(
                    new MenuItemDefinition(
                   "Users",
                        L("Users"),
                        url: "#users",
                        icon: "fa fa-users"
                      //  requiredPermissionName: PermissionNames.Pages_Users
                ))
                 .AddItem(
                    new MenuItemDefinition(
                   "Department",
                        L("Department"),
                        url: "#/departments",
                        icon: "fa fa-users"
                //  requiredPermissionName: PermissionNames.Pages_Users
                ))

                 .AddItem(
                    new MenuItemDefinition(
                   "CustomFieldSetup",
                        L("CustomFieldSetup"),
                        url: "#/customfieldsetups",
                        icon: "fa fa-users"
                //  requiredPermissionName: PermissionNames.Pages_Users
                ))




               );
                

            
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, ITrackERPConsts.LocalizationSourceName);
        }
    }
}
