import {
  createRootRoute,
  Link,
  Outlet,
  useRouterState,
} from "@tanstack/react-router";
import { TanStackRouterDevtools } from "@tanstack/router-devtools";
import { ThemeSwitcher } from "../components/theme-switcher";
import { CartDropdown } from "../components/cart-dropdown";
import { ProfileDropdown } from "../components/profile-dropdown";
import { LinksDropdown } from "../components/links-dropdown";
import isAuthenticated, { hasRole } from "../api/auth";
import { CartContext, CartItem } from "../store/cart-context";
import { useMemo, useState } from "react";

export const Route = createRootRoute({
  component: Root,
});

function Root() {
  const [cartItems, setCartItems] = useState<CartItem[]>([]);
  const cartContext = useMemo(() => ({ cartItems, setCartItems }), [cartItems]);

  return (
    <CartContext.Provider value={cartContext}>
      <Page />
    </CartContext.Provider>
  );
}

function Page() {
  const links: {
    label: string;
    to: string;
  }[] = [
    { label: "Home", to: "/" },
    { label: "Restaurants", to: "/restaurants" },
  ];

  const adminLinks = [
    { label: "Utilisateur", to: "/users" },
    { label: "Restaurant", to: "/restaurant/" },
    { label: "Menu", to: "/menu/" },
    { label: "Rapport", to: "/report" },
  ];

  const getLinks = () => {
    if (hasRole("Admin")) {
      return adminLinks;
    }
    return links;
  };

  const router = useRouterState();

  return (
    <>
      <div className="container mx-auto">
        <div className="navbar bg-base-100 shadow-md sm:rounded-xl">
          <div className="flex-1 flex items-center">
            <LinksDropdown links={links} />
            <div className="divider flex sm:hidden mx-0 my-2 divider-horizontal" />
            <Link to="/" className="btn btn-ghost text-xl">
              Pizza House
            </Link>
            <div className="divider hidden sm:flex ml-0 mr-2 my-2 divider-horizontal" />
            <div className="sm:flex items-center gap-2 hidden">
              {getLinks().map((link) => {
                const isActive = router.location.pathname === link.to;

                return (
                  <Link
                    key={link.to}
                    to={link.to}
                    className={`link ${isActive ? "" : "no-underline"}`}
                  >
                    {link.label}
                  </Link>
                );
              })}
            </div>
          </div>
          <div className="flex items-center gap-2">
            <ThemeSwitcher />
            <CartDropdown />
            {isAuthenticated() ? (
              <ProfileDropdown />
            ) : (
              <Link to="/auth/login" className="btn btn-primary text-white">
                Connexion
              </Link>
            )}
          </div>
        </div>
      </div>
      <div className="container mx-auto py-8">
        <Outlet />
      </div>
      <TanStackRouterDevtools />
    </>
  );
}
