import { useContext } from "react";
import { CartContext } from "../store/cart-context";
import { MenuItem } from "../api/menuItems";

export function MenuItemCard(menuItem: MenuItem) {
  const { addItemToCart } = useContext(CartContext);

  const handleAddToCartClick = (menuItem: MenuItem) => {
    addItemToCart(menuItem.menuItemId);
  };

  return (
    <div>
      <div className="card w-96 bg-base-100 shadow-xl">
        <figure>
          <img
            src="https://ca.ooni.com/cdn/shop/articles/20220211142645-margherita-9920.jpg?crop=center&height=915&v=1661341987&width=1200"
            alt={menuItem.name}
          />
        </figure>
        <div className="card-body">
          <h2 className="card-title">
            {menuItem.name}
            <div className="badge badge-secondary">Nouveau</div>
          </h2>
          <p>{menuItem.description}</p>
          <p>{menuItem.price + " $"}</p>
          <div className="card-actions justify-end">
            <button
              className="btn btn-danger"
              onClick={() => handleAddToCartClick(menuItem)}
            >
              Ajouter
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}
