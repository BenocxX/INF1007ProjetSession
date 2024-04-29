import { useContext } from "react";
import { MenuItem } from "../api/menuItems";
import { CartContext } from "../store/cart-context";

export function MenuItemCard(menuItem: MenuItem) {
  const { cartItems, setCartItems } = useContext(CartContext);

  function handleAddToCart() {
    setCartItems([...cartItems, { ...menuItem, quantity: 1 }]);
  }

  function handleRemoveFromCart() {
    setCartItems(
      cartItems.filter((item) => item.menuItemId !== menuItem.menuItemId)
    );
  }

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
            {cartItems.some(
              (item) => item.menuItemId === menuItem.menuItemId
            ) ? (
              <button
                className="btn btn-sm"
                onClick={() => handleRemoveFromCart()}
              >
                Retirer du panier
              </button>
            ) : (
              <button
                className="btn btn-sm btn-primary"
                onClick={() => handleAddToCart()}
              >
                Ajouter au panier
              </button>
            )}
          </div>
        </div>
      </div>
    </div>
  );
}
