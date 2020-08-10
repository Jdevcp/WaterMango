import React, { Component } from 'react';
import Spinner from 'react-bootstrap/Spinner'


export class PlantPage extends Component {

    constructor(props) {
        super(props);
        this.state = { Plants: [], loading: true, text: "Water Me!", pid: null };
        this.StartWater = this.StartWater.bind(this)
    }

    componentDidMount() {
        this.PopulatePlantData();

    }

    renderPlantTable(Plants) {
        const { text } = this.state
        return (
            <table className="table">
                <thead>
                    <tr>
                        <th>Plant</th>
                        <th>Status</th>
                        <th>Last Watered</th>
                    </tr>
                </thead>
                <tbody>
                    {Plants.map((plant, i) =>
                        <tr key={i}>
                            <td>{plant.plantName}</td>
                            <td>{plant.status}</td>
                            <td>{plant.timeLastWatered}</td>
                            <td> <button id="btnstart" className="btn btn-primary" onClick={() => { this.StartWater(plant.id); this.changeText(<Spinner animation="border" variant="info" />, plant.id) }}>{text}</button></td>
                            <td> <button id="btnstop" className="btn btn-secondary" onClick={() => { this.stopwater() } }>Stop</button> </td> 
                        </tr>
                    )}
                </tbody>
            </table>
        );
    }

    render() {
        let contents = this.state.loading

            ? <p><em>Loading...</em></p>
            : this.renderPlantTable(this.state.Plants);

        return (

            <div>
                <h1>Welcome to TapMango's plant watering system</h1>
                <p>Below you will see a list of the office plants which you can water remotely!</p>
                {contents}
               
            </div>
        );
    }


    async PopulatePlantData() {
        const response = await fetch('Plant')
        const data = await response.json();
        this.setState({ Plants: data, loading: false })

    }
    changeText = (text, i) => {
        this.setState({ text, pid: i });
    }
    stopwater() {
        window.location.reload();
    }

    async StartWater(id) {
        var sec = 10;
        var timer = setInterval(function () {
            console.log(sec);
            sec--;
            if (sec < 0) {
                clearInterval(timer);
                console.log(id);
                fetch('Water/' + id, {
                    method: 'PUT'
                }
                )
                window.location.reload();
            }
        }, 1000);

    }




}

