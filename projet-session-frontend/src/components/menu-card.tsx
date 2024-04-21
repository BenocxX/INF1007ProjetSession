import { useContext } from "react";
import { CartContext } from "../store/cart-context";

export function MenuCard(props: any) {
  const { addItemToCart } = useContext(CartContext);

  const handleAddToCartClick = (item: any) => {
    addItemToCart(item);
  };

  return (
    <div>
      <div className="card w-96 bg-base-100 shadow-xl">
        <figure>
          <img
            src="https://ca.ooni.com/cdn/shop/articles/20220211142645-margherita-9920.jpg?crop=center&height=915&v=1661341987&width=1200"
            alt={props.Name}
          />
        </figure>
        <div className="card-body">
          <h2 className="card-title">
            {props.Name}
            <div className="badge badge-secondary">Nouveau</div>
          </h2>
          <p>{props.Description}</p>
          <p>{props.Price + " $"}</p>
          <div className="card-actions justify-end">
            <button
              className="btn btn-danger"
              onClick={() => handleAddToCartClick(props)}
            >
              Ajouter
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
