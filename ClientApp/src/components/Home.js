import React, { Component } from 'react';
import { Button } from 'bootstrap';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);        
        this.state = { statuses: [], transactions: [], loading: true };
    }

    componentDidMount() {
        this.getData();
    }

    static renderStatuesTable(statuses) {
        return (            
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Mode</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {statuses.map(status =>
                        <tr key={status.id}>
                            <td>{status.id}</td>
                            <td>{status.name}</td>
                            <td>{status.mode}</td>
                            <td><button>Remove</button></td>
                        </tr>
                    )}
                </tbody>
                </table>            
        );
    }

    static renderTransactionTable(transactions) {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>From</th>
                        <th>To</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    {transactions.map(transaction =>
                        <tr key={transaction.id}>
                            <td>{transaction.id}</td>
                            <td>{transaction.from}</td>
                            <td>{transaction.to}</td>
                            <td><button>Remove</button></td>
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let loadingcontext = <p><em>Loading...</em></p>;
        let statusTable = loadingcontext;
        let transactionsTable = loadingcontext;

        if (!this.state.loading) {
            statusTable = Home.renderStatuesTable(this.state.statuses);
            transactionsTable = Home.renderTransactionTable(this.state.transactions);
        }

        return (
            <div>
                <h1 id="tabelLabel" >Statuses List</h1>
                <button onClick="" className="btn-style">Add a new status</button>
                {statusTable}
                <h1 id="tabelLabel" >Transactions List</h1>
                <button onClick="" className="btn-style">Add a new transaction</button>
                {transactionsTable}                
                <button onClick="" className="btn-style error-color">Reset All</button>
            </div>
        );
    }

    async getData() {
        const statusResponse = await fetch('StatusController');
        const statusData = await statusResponse.json();

        const TransactionResponse = await fetch('Transactions');
        const TransactionData = await TransactionResponse.json();

        this.setState({ statuses: statusData, transactions: TransactionData  , loading: false });
    }


}