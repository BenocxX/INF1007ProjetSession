import { createContext } from "react";
import { MenuItem } from "../api/menuItems";

export type CartItem = MenuItem & { quantity: number };

export const CartContext = createContext({
  cartItems: [] as CartItem[],
  // eslint-disable-next-line @typescript-eslint/no-unused-vars
  setCartItems: (cartItems: CartItem[]) => {},
});
