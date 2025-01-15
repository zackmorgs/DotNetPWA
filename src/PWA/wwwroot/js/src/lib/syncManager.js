window.syncWeatherForecasts = async () => {
    const forecasts = await window.getFromIndexedDb('forecasts');

    console.log('syncWeatherForecasts', JSON.stringify(forecasts));

    // do http PUT request to update MS SQL database
    fetch('https://localhost:7092/weatherforecast?GetWeatherForecast?SetWeatherForecast', {
        method: 'PUT', // Specifies the HTTP method
        headers: {
            'Content-Type': 'application/json', // Indicates the type of data sent
        },
        body: JSON.stringify(forecasts), // The payload as a JSON string
    })
        .then(response => {
            if (!response.ok) {
                throw new Error(`HTTP error! Status: ${response.status}`);
            }
            return response.json();
        })
        .then(data => {
            console.log('Success:', data);
        })
        .catch(error => {
            console.error('Error:', error);
        });

    // if successful, remove from indexedDb

    //  
}