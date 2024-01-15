import React, { Component } from 'react'
import Dropdown from 'react-dropdown';
import './components.css'

export class Vote extends Component {

    
    constructor(props) {
        super(props);
        this.state = {
            voters: [],
            candidates: [],
            loading: true,
            selectedCandidate: null,
            selectedVoter:null
        };
    }

    componentDidMount() {
        this.loadVoters();
        this.loadCandidates();
    }
    
    voting = (e) => {
        e.preventDefault();
        console.log(this.state.selectedCandidate.name);
        const response = fetch('http://localhost:5062/api/vote', {
            method: "POST",
            body: JSON.stringify({
                voter: this.state.selectedVoter,
                candidate: this.state.selectedCandidate
            }),
            headers: {
                "Content-type": "application/json; charset=UTF-8"
            }
        });
    }

    selectCandidate = (e) => {
        this.setState({ selectedCandidate: e.value });
    }

    selectVoter = (e) => {
        this.setState({ selectedVoter: e.value });
    }

    render() {
        return (            
            <form>
                <table>
                    <tr>
                        <h3>Vote!</h3>
                    </tr>
                    <tr>
                        <td className= "vote_table_choise">
                            <Dropdown options={this.state.voters}
                                onChange={this.selectVoter}
                                placeholder="I am" />
                        </td>
                        <td className="vote_table_choise">
                            <Dropdown options={this.state.candidates}
                                onChange={this.selectCandidate}
                                placeholder="I vote for" />
                        </td>
                        <td className="vote_table_submit">
                            <button onClick={this.voting} type="submit">
                                 Submit!
                             </button>
                         </td>
                    </tr>
                </table>
            </form>
        );
    }


    async loadVoters() {
        const response = await fetch('http://localhost:5062/api/voters');
        const data = await response.json();

        let voters = [];

        data.forEach((voter) => voters.unshift({ value: voter, label: voter.name }));

        this.setState({ voters: voters, loading: false });
    }

    async loadCandidates() {
        const response = await fetch('http://localhost:5062/api/candidates');
        const data = await response.json();

        let candidates = [];

        data.forEach((candidate) => candidates.unshift({ value: candidate, label: candidate.name }));
                
        this.setState({ candidates: candidates, loading: false });
    }
}