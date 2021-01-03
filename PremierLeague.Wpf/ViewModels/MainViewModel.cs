using PremierLeague.Core.Contracts;
using PremierLeague.Core.DataTransferObjects;
using PremierLeague.Persistence;
using PremierLeague.Wpf.Common;
using PremierLeague.Wpf.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PremierLeague.Wpf.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
        private ObservableCollection<TeamTableRowDto> _games;
        public ObservableCollection<TeamTableRowDto> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }
    public MainViewModel(IWindowController windowController) : base(windowController)
    {
      LoadCommands();
    }

    /// <summary>
    /// Erstellt die notwendigen Commands.
    /// </summary>
    private void LoadCommands()
    {
      //throw new NotImplementedException();
    }

    /// <summary>
    /// Asynchrones Laden von Daten für das ViewModel.
    /// Wird in CreateAsync(..) aufgerufen.
    /// </summary>
    /// <returns></returns>
    private async Task LoadDataAsync()
    {
            using IUnitOfWork uow = new UnitOfWork();
            var games = await uow.Games.GetAllAsync();
            Games = new ObservableCollection<TeamTableRowDto>();
            foreach(var game in games)
            {
                Games.Add(game);
            }
    }

    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
            yield return ValidationResult.Success;
    }

    public static async Task<MainViewModel> CreateAsync(IWindowController windowController)
    {
      var viewModel = new MainViewModel(windowController);
      await viewModel.LoadDataAsync();
      return viewModel;
    }

        private ICommand _cmdAddGame;
        public ICommand CmdAddGame
        {
            get
            {
                if(_cmdAddGame == null)
                {
                    _cmdAddGame = new RelayCommand(
                        execute: _ =>
                        {
                            Controller.ShowWindow(new AddGameViewModel(Controller), true);
                            LoadDataAsync();
                        },
                        canExecute: _ => true
                        );
                }
                return _cmdAddGame;
            }
            set => _cmdAddGame = value;
        }
  }
}
