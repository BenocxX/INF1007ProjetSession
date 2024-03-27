import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/weather-forecast")({
  component: WeatherForecast,
});

function WeatherForecast() {
  return <div className="p-2">Hello from Weather!</div>;
}
