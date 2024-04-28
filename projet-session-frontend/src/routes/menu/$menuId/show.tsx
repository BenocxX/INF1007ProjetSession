import { useEffect, useState } from "react";
import { createFileRoute, useParams } from "@tanstack/react-router";
import { MenuCard } from "../../../components/menu-card";
import { MenuItem } from "../../../api/menuItems";
import { fetchMenuById } from "../../../api/menu";

export const Route = createFileRoute("/menu/$menuId/show")({
  component: DisplayMenuItem,
  staleTime: 0,
});

function DisplayMenuItem() {
  const { menuId } = useParams({ strict: false });
  const [data, setData] = useState<any>([]);
  let [menuList, setMenuList] = useState([]);

  useEffect(() => {
    const id = parseInt(menuId, 10);
    fetchItem(id);

    const menus = data.map((menu: MenuItem) => <MenuCard {...menu} />);
    setMenuList(menus);
  }, []);

  useEffect(() => {
    const id = parseInt(menuId, 10);
    fetchItem(id);
  }, [menuId]);

  const fetchItem = async (id: number) => {
    try {
      const menuData = await fetchMenuById(id);
      setData(menuData.menuItems.map((item: any) => item));
    } catch (error) {
      console.error("Error fetching menu item:", error);
    }
  };

  useEffect(() => {
    const menus = data.map((menu: MenuItem) => <MenuCard {...menu} />);
    setMenuList(menus);
  }, [data]);

  return (
    <div>
      <h1 className="text-center text-3xl mb-4">Nos plats</h1>
      {menuList.length > 0 ? (
        <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-4">
          {menuList}
        </div>
      ) : (
        <div>Loading...</div>
      )}
    </div>
  );
}
