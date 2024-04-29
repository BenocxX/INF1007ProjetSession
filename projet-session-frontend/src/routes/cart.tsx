import { createFileRoute } from "@tanstack/react-router";
import { useContext, useEffect, useState } from "react";
import { CartContext } from "../store/cart-context";

export const Route = createFileRoute("/cart")({
  component: CartPage,
});

function CartPage() {
  const { cartItems, setCartItems } = useContext(CartContext);
  const [total, setTotal] = useState(0);

  useEffect(() => {
    const newTotal = cartItems.reduce(
      (acc, item) => acc + item.price * item.quantity,
      0
    );
    setTotal(newTotal);
  }, [cartItems]);

  const handleQuantityChange = (itemId: number, newQuantity: number) => {
    setCartItems(
      cartItems.map((item) =>
        item.menuItemId === itemId ? { ...item, quantity: newQuantity } : item
      )
    );
  };

  const handleRemoveItem = (itemId: number) => {
    setCartItems(cartItems.filter((item) => item.menuItemId !== itemId));
  };

  return (
    <div className="container mx-auto mt-10 p-4">
      <h1 className="text-2xl mb-4">Panier</h1>
      {cartItems.length === 0 ? (
        <p className="text-xl">Votre panier est vide.</p>
      ) : (
        <div className="overflow-x-auto">
          <table className="table table-xs table-pin-rows table-pin-cols">
            {/* head */}
            <thead>
              <tr>
                <th className="text-lg">Nom</th>
                <th className="text-lg">Description</th>
                <th className="text-lg">Quantité</th>
                <th className="text-lg">Prix</th>
              </tr>
            </thead>
            <tbody>
              {/* row 1 */}
              {cartItems.map((cartItem) => (
                <tr key={cartItem.menuItemId}>
                  <th className="text-lg">{cartItem.name}</th>
                  <td className="text-lg">{cartItem.description}</td>
                  <td>
                    <select
                      className="select w-full max-w-xs select-primary"
                      value={cartItem.quantity}
                      onChange={(e) =>
                        handleQuantityChange(
                          cartItem.menuItemId,
                          Number(e.target.value)
                        )
                      }
                    >
                      <option disabled>Choisir une quantité</option>
                      {[...Array(10)].map((_, index) => (
                        <option key={index + 1} value={index + 1}>
                          {index + 1}
                        </option>
                      ))}
                    </select>
                  </td>
                  <td className="text-lg">{cartItem.price}</td>
                  <th>
                    {" "}
                    <button
                      className="btn btn-error btn-xs text-white"
                      onClick={() => handleRemoveItem(cartItem.menuItemId)}
                    >
                      Supprimer
                    </button>
                  </th>
                </tr>
              ))}
            </tbody>
            <tfoot>
              <tr>
                <td className="text-lg">Total:</td>
                <td></td>
                <td></td>
                <td className="text-lg">
                  {total.toFixed(2)} {" $"}
                </td>
              </tr>
            </tfoot>
          </table>
        </div>
      )}
      <div className="flex justify-end">
        <button className="btn btn-active btn-neutral my-5">
          Passer la commande
        </button>
      </div>
    </div>
  );
}
