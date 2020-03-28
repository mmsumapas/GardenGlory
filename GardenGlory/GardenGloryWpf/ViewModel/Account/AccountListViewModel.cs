using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using ServiceLayer;

namespace GardenGloryWpf.ViewModel.Account
{
    public class AccountListViewModel
    {
        private AccountService _accountService;
        private string _searchText;

        public AccountListViewModel(AccountService accountService)
        {
            _accountService = accountService;
            AccountList = new ObservableCollection<AccountViewModel>(_accountService.GetAccounts().Select(c=> new AccountViewModel(c)));
        }

        public void SearchAccount(string searchString)
        {
            AccountList.Clear();
            var accounts = _accountService.GetAccounts().Where(c => c.Username.Contains(searchString)||
                c.EmployeeLink.LastName.Contains(searchString)
                || c.EmployeeLink.FirstName.Contains(searchString)
                || c.EmployeeId.Contains(searchString));
            foreach (var account in accounts)
            {
                var accountModel = new AccountViewModel(account);
                AccountList.Add(accountModel);
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                SearchAccount(_searchText);
            }
        }
        public ObservableCollection<AccountViewModel> AccountList { get; set; }
        public AccountViewModel SelectedAccount { get; set; } 
    }
}
