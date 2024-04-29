import { Link } from "@tanstack/react-router";
import Cookies from "js-cookie";
import { getUserEmail, getUserId } from "../api/auth";

export function ProfileDropdown() {
  const handleLogout = () => {
    Cookies.remove("jwtToken");
    location.replace("/auth/login");
  };

  const userId = getUserId();
  const email = getUserEmail();

  return (
    <div className="dropdown dropdown-end">
      <div
        tabIndex={0}
        role="button"
        className="btn btn-sm btn-ghost btn-circle avatar"
      >
        <div className="w-6 rounded-full">
          <img
            alt="Tailwind CSS Navbar component"
            src="https://daisyui.com/images/stock/photo-1534528741775-53994a69daeb.jpg"
          />
        </div>
      </div>
      <ul
        tabIndex={0}
        className="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-100 rounded-box w-52"
      >
        <li>
          <span className="text-sm font-bold">{email}</span>
        </li>
        <hr className="mx-2 mb-2" />
        {userId && (
          <li>
            <Link
              to="/orders/user/$userId"
              params={{ userId: userId.toString() }}
            >
              Commandes
            </Link>
          </li>
        )}
        <li>
          <a onClick={handleLogout}>Logout</a>
        </li>
      </ul>
    </div>
  );
}
