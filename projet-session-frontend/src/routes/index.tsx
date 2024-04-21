import { Link, createFileRoute } from "@tanstack/react-router";
import { useEffect, useState } from "react";
import { Restaurant } from "../api/restaurant";

export const Route = createFileRoute("/")({
  component: Index,
});

function Index() {
  const [restaurants, setRestaurants] = useState<Restaurant[]>([]);

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/restaurant`)
      .then((response) => response.json())
      .then((json) => setRestaurants(json))
      .catch((error) => console.log(error));
  }, []);

  return (
    <div>
      <h1 className="text-center text-3xl mb-4">Nos restaurants</h1>
      <div className="grid grid-cols-4 gap-4">
        {}
        {restaurants ? (
          restaurants.map((restaurant) => (
            <div className="card w-96 bg-base-100 shadow-xl">
              <figure>
                <img
                  src="https://seeklogo.com/images/P/pizza-logo-E6DE845BD3-seeklogo.com.png"
                  alt="Shoes"
                />
              </figure>
              <div className="card-body">
                <h2 className="card-title">{restaurant.name}</h2>
                <p>{restaurant.address}</p>
                <div className="card-actions justify-end">
                  <Link
                    to="/menu/$menuId/show"
                    params={{ menuId: restaurant.menuId.toString() }}
                    className="btn btn-warning text-white"
                  >
                    Voir le menu
                  </Link>
                </div>
              </div>
            </div>
          ))
        ) : (
          <div>Chargement...</div>
        )}
      </div>
    </div>
  );
}
