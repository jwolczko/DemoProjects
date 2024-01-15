import React, { Component } from 'react';
import { Voters } from './Voters'
import { Candidates } from './Candidates'
import { Vote } from './Vote'
import AddPersonFrom from './AddPersonForm'
import './components.css'
import 'react-dropdown/style.css';

export class Home extends Component {
    static displayName = 'Voting app';

    constructor(props) {
        super(props)
        this.state = this.state = { voters: [], candidates: [], loading: true };
    }

    componentDidMount() {
        this.loadVoters();
        this.loadCandidates();
    }

    addPerson = (e) => {
        e.preventDefault();
        console.log(e.target.value);
    }


    addVoter = (e) => {
        e.preventDefault();
        console.log(e.target.value);
    }

    addCandidate = (e) => {
        e.preventDefault();
        console.log(e.target.value);
    }

    render() {
        return (
            <div>
                <div>
                    <h1>Voting app</h1>
                    <div className="component">
                        <table>
                            <tr>
                                <td><h3>Voters</h3></td>
                                <td className="content_buttons">
                                    <button className="header" onClick={this.addVoter}>+</button>
                                </td>
                            </tr>
                        </table>

                        <Voters items={this.state.voters} />
                    </div>
                    <div className="component">
                        <table>
                            <tr>
                                <td><h3>Candidates</h3></td>
                                <td className="content_buttons">
                                    <button className="header" onClick={this.addCandidate}>+</button>
                                </td>
                            </tr>                           
                        </table>
                        <Candidates items={this.state.candidates} />
                    </div>
                    
                </div>

                <div>
                    <Vote/>
                </div>

                <div>
                    <AddPersonFrom/>
                </div>
            </div>
        );
    }

    async loadVoters() {
        const response = await fetch('http://localhost:5062/api/voters');
        const data = await response.json();
        this.setState({ voters: data, loading: false });
    }


    async loadCandidates() {
        const response = await fetch('http://localhost:5062/api/candidates');
        const data = await response.json();
        this.setState({ candidates: data, loading: false });
    }   
}
