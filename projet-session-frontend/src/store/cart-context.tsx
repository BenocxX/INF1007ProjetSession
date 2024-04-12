import { createContext, ReactNode, useEffect, useReducer } from "react";

type CartItem = {
  id: number;
  quantity: number;
  name: string;
  description: string;
  price: number;
};

type CartContextType = {
  items: CartItem[];
  addItemToCart: (id: number) => void;
  updateCartItemQuantity: (id: number, newQuantity: number) => void;
  removeCartItem: (id: number) => void;
};

type CartContextProviderProps = {
  children: ReactNode;
};

export const CartContext = createContext<CartContextType>({
  items: [],
  addItemToCart: () => {},
  updateCartItemQuantity: () => {},
  removeCartItem: () => {},
});

const cartReducer = (state: any, action: any) => {
  switch (action.type) {
    case "ADD_TO_CART":
      const updatedCartItems = [...state.items];

      const existingElementIndex = updatedCartItems.findIndex(
        (cartItem: CartItem) => cartItem.id == action.payload.item.id
      );

      if (updatedCartItems[existingElementIndex]) {
        updatedCartItems[existingElementIndex].quantity += 1;
      } else {
        updatedCartItems.push({
          id: action.payload.item.id,
          quantity: 1,
          price: action.payload.item.price,
          name: action.payload.item.name,
          description: action.payload.item.description,
        });
      }
      localStorage.setItem("cartItems", JSON.stringify(updatedCartItems));

      return { ...state, items: updatedCartItems };
    default:
      return state;
  }
};

export const CartContextProvider = ({ children }: CartContextProviderProps) => {
  const [cartState, cartDispatch] = useReducer(cartReducer, {
    items: JSON.parse(localStorage.getItem("cartItems") || "[]"),
  });

  useEffect(() => {
    const storedItems = JSON.parse(localStorage.getItem("cartItems") || "[]");
    cartDispatch({ type: "SET_CART_ITEMS", payload: { items: storedItems } });
  }, []);

  const handleAddToCart = (menuItem: any) => {
    cartDispatch({
      type: "ADD_TO_CART",
      payload: { item: menuItem },
    });
  };

  const handleUpdateCartItemQuantity = (id: number, newQuantity: number) => {
    const updatedItems = cartState.items.map((item: any) =>
      item.id === id ? { ...item, quantity: newQuantity } : item
    );

    localStorage.setItem("cartItems", JSON.stringify(updatedItems));

    cartDispatch({
      type: "UPDATE_CART_ITEM_QUANTITY",
      payload: { items: updatedItems },
    });
  };

  const handleRemoveCartItem = (id: number) => {
    const updatedItems = cartState.items.filter((item: any) => item.id !== id);

    localStorage.setItem("cartItems", JSON.stringify(updatedItems));

    cartDispatch({
      type: "REMOVE_CART_ITEM",
      payload: { items: updatedItems },
    });
  };

  const initialValue: CartContextType = {
    items: cartState.items,
    addItemToCart: handleAddToCart,
    updateCartItemQuantity: handleUpdateCartItemQuantity,
    removeCartItem: handleRemoveCartItem,
  };

  return (
    <CartContext.Provider value={initialValue}>{children}</CartContext.Provider>
  );
};
