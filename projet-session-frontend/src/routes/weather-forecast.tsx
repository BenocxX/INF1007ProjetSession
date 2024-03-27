import { createFileRoute } from "@tanstack/react-router";
import { useEffect, useState } from "react";

export const Route = createFileRoute("/weather-forecast")({
  component: WeatherForecast,
});

type WeatherForecast = {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
};

function WeatherForecast() {
  const [weather, setWeather] = useState<WeatherForecast[] | null>(null);

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/weatherforecast`)
      .then((res) => res.json())
      .then((data) => {
        setWeather(data);
      })
      .catch((error) => {
        console.error("Error:", error);
        setWeather(null);
      });
  }, []);

  return (
    <div className="p-2">
      <h1 className="text-xl">Here's the weather</h1>
      {weather === null && <p>Loading...</p>}
      {weather && weather.length === 0 && <p>No weather data available</p>}
      {weather && weather.length > 0 && (
        <table className="table table-compact">
          <thead>
            <tr>
              <th>Date</th>
              <th>Temperature (C)</th>
              <th>Temperature (F)</th>
              <th>Summary</th>
            </tr>
          </thead>
          <tbody>
            {weather.map((forecast) => (
              <tr key={forecast.date}>
                <td>{forecast.date}</td>
                <td>{forecast.temperatureC}</td>
                <td>{forecast.temperatureF}</td>
                <td>{forecast.summary}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}
