import { createFileRoute, redirect } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { fetchMenuByRestaurantId } from "../../api/menu";

export const Route = createFileRoute("/restaurant/showAll")({
  component: Restaurant,
});

function Restaurant() {
  const [restaurants, setRestaurants] = useState<any[]>([]);

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/restaurant`)
      .then((response) => response.json())
      .then((json) => setRestaurants(json))
      .catch((error) => console.log(error));
  }, []);

  const consultMenu = async (id: number) => {
    const response = await fetchMenuByRestaurantId(id);
  };

  return (
    <div className="p-2">
      <h1 className="text-center text-3xl mb-5">Nos restaurant</h1>
      <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-4">
        {restaurants.map((item) => (
          <div className="card w-96 bg-base-100 shadow-xl">
            <figure>
              <img
                src="https://seeklogo.com/images/P/pizza-logo-E6DE845BD3-seeklogo.com.png"
                alt="Shoes"
              />
            </figure>
            <div className="card-body">
              <h2 className="card-title">{item.name}</h2>
              <p>{item.city}</p>
              <div className="card-actions justify-end">
                <button
                  onClick={() => consultMenu(item.restaurantID)}
                  className="btn btn-primary"
                >
                  Consulter le menu
                </button>
              </div>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
}
