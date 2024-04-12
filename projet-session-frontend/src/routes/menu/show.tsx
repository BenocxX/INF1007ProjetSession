import React, { useEffect, useState } from "react";
import { createFileRoute } from "@tanstack/react-router";
import { MenuCard } from "../../components/menu-card";
import { MenuItem } from "../../api/menuItems";

export const Route = createFileRoute("/menu/show")({
  component: DisplayMenuItem,

  staleTime: 0,
});

function DisplayMenuItem() {
  const [data, setData] = useState<any>(null);
  let [menuList, setMenuList] = useState([]);

  useEffect(() => {
    fetch(`${import.meta.env.VITE_API_URL}/menu`)
      .then((response) => response.json())
      .then((json) => setData(json))
      .catch((error) => console.log(error));
  }, []);

  useEffect(() => {
    if (data) {
      const menus = data.map((menu: MenuItem) => <MenuCard {...menu} />);
      setMenuList(menus);
    }
  }, [data]);

  return (
    <div>
      {menuList.length > 0 ? <div>{menuList}</div> : <div>Loading...</div>}
    </div>
  );
}
