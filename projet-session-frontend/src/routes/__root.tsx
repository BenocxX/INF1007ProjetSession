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

export const Route = createRootRoute({
  component: Root,
});

function Root() {
  const links: {
    label: string;
    to: string;
  }[] = [
    { label: "Home", to: "/" },
    { label: "Weather", to: "/weather-forecast" },
    { label: "Users", to: "/users" },
    { label: "Menu", to: "/menu/show" },
  ];

  const router = useRouterState();

  return (
    <>
      <div className="container mx-auto">
        <div className="navbar bg-base-100 shadow-md sm:rounded-xl">
          <div className="flex-1 flex items-center">
            <LinksDropdown links={links} />
            <div className="divider flex sm:hidden mx-0 my-2 divider-horizontal" />
            <Link to="/" className="btn btn-ghost text-xl">
              ProjetSession
            </Link>
            <div className="divider hidden sm:flex ml-0 mr-2 my-2 divider-horizontal" />
            <div className="sm:flex items-center gap-2 hidden">
              {links.map((link) => {
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
            <ProfileDropdown />
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
