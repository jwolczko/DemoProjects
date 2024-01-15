import React, { Component } from 'react'
import './components.css'

export class Candidates extends Component {

    constructor(props) {
        super(props);
    }

    static renderCandidatesTable(candidates) {
        return (
            <table className="table table-striped" aria-labelledby="tableLabel">
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Name</th>
                        <th>Votes</th>
                    </tr>
                </thead>
                <tbody>
                    {candidates.map(candidate =>
                        <tr key={candidate.id}>
                            <td>{candidate.id}</td>
                            <td>{candidate.name}</td>
                            <td>{candidate.votesNumber}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        return (
            <div>
                {Candidates.renderCandidatesTable(this.props.items)}
            </div>
        );
    }
}