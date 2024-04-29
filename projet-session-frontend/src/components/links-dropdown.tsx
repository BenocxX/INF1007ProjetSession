import { Link } from "@tanstack/react-router";
import { LinkProps } from "../routes/__root";

function MenuIcon() {
  return (
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
  );
}

export function LinksDropdown({ links }: { links: LinkProps[] }) {
  return (
    <div className="dropdown sm:hidden block">
      <div tabIndex={0} role="button" className="btn btn-ghost btn-square">
        <MenuIcon />
      </div>
      <ul
        tabIndex={0}
        className="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-100 rounded-box w-52"
      >
        {links.map((link) => (
          <li key={link.to}>
            <Link to={link.to} params={link.params}>
              {link.label}
            </Link>
          </li>
        ))}
      </ul>
    </div>
  );
}
