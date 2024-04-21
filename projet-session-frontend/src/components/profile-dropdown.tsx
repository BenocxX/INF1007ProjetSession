import Cookies from "js-cookie";

export function ProfileDropdown() {
  const handleLogout = () => {
    Cookies.remove("jwtToken");
    location.replace("/auth/login");
  };

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
          <a className="justify-between">
            Profil
            <span className="badge">Nouveau</span>
          </a>
        </li>
        <li>
          <a>Paramètre</a>
        </li>
        <li>
          <a onClick={handleLogout}>Logout</a>
        </li>
      </ul>
    </div>
  );
}
