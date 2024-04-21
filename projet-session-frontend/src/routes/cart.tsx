import { createFileRoute } from "@tanstack/react-router";
import { useContext, useEffect, useState } from "react";
import { CartContext } from "../store/cart-context";

export const Route = createFileRoute("/cart")({
  component: CartPage,
});

function CartPage() {
  const { items, updateCartItemQuantity, removeCartItem } =
    useContext(CartContext);
  const [cartItems, setCartItems] = useState(items);
  const [total, setTotal] = useState(0);

  useEffect(() => {
    setCartItems(items);
    calculateTotal();
  }, [items]);

  const calculateTotal = () => {
    const newTotal = parseFloat(
      cartItems
        .reduce((acc, item) => acc + item.quantity * item.price, 0)
        .toFixed(2)
    );
    setTotal(newTotal);
  };

  const handleQuantityChange = (itemId: number, newQuantity: number) => {
    updateCartItemQuantity(itemId, newQuantity);
    calculateTotal();
  };

  const handleRemoveItem = (itemId: number) => {
    removeCartItem(itemId);
    setCartItems(cartItems.filter((item) => item.MenuItemId !== itemId));
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
              {cartItems.map((item) => (
                <tr>
                  <th className="text-lg">{item.name}</th>
                  <td className="text-lg">{item.description}</td>
                  <td>
                    <select
                      className="select w-full max-w-xs select-primary"
                      value={item.quantity}
                      onChange={(e) =>
                        handleQuantityChange(item.id, Number(e.target.value))
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
                  <td className="text-lg">{item.price}</td>
                  <th>
                    {" "}
                    <button
                      className="btn btn-error btn-xs text-white"
                      onClick={() => handleRemoveItem(item.MenuItemId)}
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
                  {total} {" $"}
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
