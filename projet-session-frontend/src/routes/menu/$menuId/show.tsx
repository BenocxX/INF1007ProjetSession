import { createFileRoute } from "@tanstack/react-router";
import { fetchMenuById } from "../../../api/menu";
import { MenuItemCard } from "../../../components/menu-card";
import { MenuItem } from "../../../api/menuItems";

export const Route = createFileRoute("/menu/$menuId/show")({
  component: DisplayMenuItem,
  loader: async ({ params }) => {
    return fetchMenuById(+params.menuId);
  },
  staleTime: 0,
});

function DisplayMenuItem() {
  const menu = Route.useLoaderData();

  return (
    <div>
      <h1 className="text-center text-3xl mb-4">Nos plats</h1>
      {menu ? (
        <MenuItemList menuItems={menu.menuItems} />
      ) : (
        <div>Loading...</div>
      )}
    </div>
  );
}

function MenuItemList({ menuItems }: { menuItems: MenuItem[] }) {
  const menuItemCards = menuItems.map((menu) => (
    <MenuItemCard key={menu.menuItemId} {...menu} />
  ));

  return (
    <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-4">
      {menuItems.length > 0 ? menuItemCards : <div>No menu items found</div>}
    </div>
  );
}
