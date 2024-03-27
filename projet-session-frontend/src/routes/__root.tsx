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

export const Route = createRootRoute({
  component: Root,
});

function Root() {
  const links = [
    {
      label: "Home",
      to: "/",
    },
    {
      label: "About",
      to: "/about",
    },
  ];

  const router = useRouterState();

  return (
    <>
      <div className="container mx-auto">
        <div className="navbar bg-base-100 shadow-md sm:rounded-xl">
          <div className="flex-1 flex items-center">
            <div className="dropdown sm:hidden block">
              <div
                tabIndex={0}
                role="button"
                className="btn btn-ghost btn-square"
              >
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
                    d="M4 6h16M4 12h16M4 18h7"
                  />
                </svg>
              </div>
              <ul
                tabIndex={0}
                className="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-100 rounded-box w-52"
              >
                {links.map((link) => (
                  <li key={link.to}>
                    <Link to={link.to}>{link.label}</Link>
                  </li>
                ))}
              </ul>
            </div>
            <div className="divider flex sm:hidden mx-0 my-2 divider-horizontal"></div>
            <Link to="/" className="btn btn-ghost text-xl">
              ProjetSession
            </Link>
            <div className="divider hidden sm:flex ml-0 mr-2 my-2 divider-horizontal"></div>
            <div className="sm:flex items-center gap-2 hidden">
              {links.map((link) => {
                const isActive = router.location.pathname === link.to;

                return (
                  <Link
                    key={link.to}
                    to={link.to}
                    className={`link ${isActive ? "link-primary" : "no-underline"}`}
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
      <Outlet />
      <TanStackRouterDevtools />
    </>
  );
}
