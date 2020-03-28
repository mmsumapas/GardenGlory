using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GardenGlory.EfClasses;
using GardenGloryWpf.ViewModel.Account;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.CmbViewModel
{
    public class RoleCmbViewModel
    {
        private string _searchRoleText;
        private RoleService _roleService;
        public AccountViewModel AssociatedAccountViewModel { get;  }
        public RoleCmbViewModel(AccountViewModel accountViewModel,RoleService roleService)
        {
            AssociatedAccountViewModel = accountViewModel;
            _roleService = roleService;
            Roles = new ObservableCollection<Role>(_roleService.GetRoles());
            SelectedRole = Roles.First(c => c.RoleId == AssociatedAccountViewModel.RoleId);
        }

        public RoleCmbViewModel(RoleService roleService)
        {
            _roleService = roleService;
            Roles = new ObservableCollection<Role>(_roleService.GetRoles());
        }
        public string SeachRoleText
        {
            get => _searchRoleText;
            set
            {
                _searchRoleText = value;
                if (_searchRoleText == null)
                {
                    _searchRoleText = "";
                    SearchRole(_searchRoleText);
                }
                else
                {
                    SearchRole(_searchRoleText);
                }
            }

        }
        public void SearchRole(string searchText)
        {
            var roles = _roleService.GetRoles().Where(c => c.RoleType.Contains(searchText));
            Roles.Clear();
            foreach (var role in roles)
            {
                Roles.Add(role);

            }
        }

        public ObservableCollection<Role> Roles { get; set; }
        public Role SelectedRole { get; set; }
    }
}
