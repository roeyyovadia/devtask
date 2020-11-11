import React from 'react';
import { Button } from 'bootstrap';

class Popup extends Component {
    constructor() {
        super();
        this.state = {
            showPopup: false
        };
    }
    //tooglePopup is a method name
    togglePopup() {
        //Set the state
        this.setState({
            showPopup: !this.state.showPopup
        });
    }
    render() {
        return (
            <div className='app'>

                <button onClick={this.togglePopup.bind(this)}>show popup</button>
                {this.state.showPopup ?
                    <TodoListCourse
                        text='User List'
                        closePopup={this.togglePopup.bind(this)}
                    />
                    : null
                }
            </div>
        );
    }
};