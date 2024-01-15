using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Vode.Desktop.Command;
using Vode.Desktop.Model;
using Vote.Model;

namespace Vode.Desktop.ViewModel
{
    public class VoteViewModel : ObservableObject
    {
        private Voter _selectedVoter;
        private Candidate _selectedCandiate;
        private ObservableCollection<Voter> _voters;
        private ObservableCollection<Candidate> _canddates;
        public ICommand _addVoterCommand;
        public ICommand _addCandidateCommand;
        public ICommand _voteCommand;
        public ICommand _getDataCommand;
        public IVoteApiClient _apiClient;


        public string AppName => "Voting app";

        public Voter SelectedVoter 
        { 
            get =>_selectedVoter; 
            set => SetProperty(ref _selectedVoter, value); 
        }

        public Candidate SelectedCandidate 
        { 
            get => _selectedCandiate; 
            set => SetProperty(ref _selectedCandiate, value); 
        }

        public ObservableCollection<Voter> Voters 
        {
            get => _voters; 
            set => SetProperty(ref _voters, value);
        }

        public ObservableCollection<Candidate> Candidates 
        { 
            get => _canddates; 
            set => SetProperty(ref _canddates, value); 
        }

        public ICommand AddVoterCommand 
        {
            get => _addVoterCommand;
            set => SetProperty(ref _addVoterCommand, value); 
        }
        public ICommand AddCandidateCommand 
        { 
            get => _addCandidateCommand;
            set => SetProperty(ref _addCandidateCommand, value); 
        }

        public ICommand VoteCommand 
        { 
            get => _voteCommand;
            set => SetProperty(ref _voteCommand, value); 
        }

        public ICommand GetDataCommand 
        {
            get => _getDataCommand; 
            set => SetProperty(ref _getDataCommand, value);
        }


        public VoteViewModel(IVoteApiClient voteApiClient)
        {
            _apiClient = voteApiClient;

            GetDataCommand = new GetDataCommand(this, _apiClient);            
            VoteCommand = new VoteCommand(this, _apiClient);
            AddCandidateCommand = new AddPersonCommand(this, _apiClient, PersonType.Candidate);
            AddVoterCommand = new AddPersonCommand(this, _apiClient, PersonType.Voter);
        }
    }
}
