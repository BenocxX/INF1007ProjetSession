import { useContext, useEffect, useState } from "react";
import { CartContext } from "../store/cart-context";
import { Link } from "@tanstack/react-router";

export function CartDropdown() {
  const { items } = useContext(CartContext);
  const [numberItem, setNumberItem] = useState(0);
  const [subTotal, setSubtotal] = useState(0);
  const [cartItem, setCartItem] = useState([...items]);

  useEffect(() => {
    setCartItem([...items]);
    UpdateQuantities();
    UpdateSubTotal();
  }, [items]);

  function UpdateQuantities() {
    let quantity = 0;
    items.forEach((element) => {
      quantity += element.quantity;
    });
    setNumberItem(quantity);
  }

  function UpdateSubTotal() {
    let total = 0;
    items.forEach((element) => {
      total += element.price * element.quantity;
    });
    setSubtotal(total);
  }

  return (
    <div className="dropdown dropdown-end">
      <div
        tabIndex={0}
        role="button"
        className="btn btn-sm btn-ghost btn-circle"
      >
        <div className="indicator">
          <svg
            xmlns="http://www.w3.org/2000/svg"
            className="h-5 w-5"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              strokeWidth="2"
              d="M3 3h2l.4 2M7 13h10l4-8H5.4M7 13L5.4 5M7 13l-2.293 2.293c-.63.63-.184 1.707.707 1.707H17m0 0a2 2 0 100 4 2 2 0 000-4zm-8 2a2 2 0 11-4 0 2 2 0 014 0z"
            />
          </svg>
          <span className="badge badge-sm indicator-item">{numberItem}</span>
        </div>
      </div>
      <div
        tabIndex={0}
        className="mt-3 z-[1] card card-compact dropdown-content w-52 bg-base-100 shadow"
      >
        <div className="card-body">
          <span className="font-bold text-lg">{numberItem} items</span>
          <span className="text-info">
            Sous-total: {subTotal.toFixed(2) + " $"}
          </span>
          <div className="card-actions">
            <Link to="/cart">
              <button className="btn btn-primary btn-block">
                Voir le panier
              </button>
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
}
