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

// function DisplayMenuItem2() {
//   const { menuId } = useParams({ strict: false });
//   const [data, setData] = useState<any>([]);
//   let [menuList, setMenuList] = useState([]);

//   useEffect(() => {
//     const id = parseInt(menuId, 10);
//     fetchItem(id);

//     const menus = data.map((menu: MenuItem) => <MenuCard {...menu} />);
//     setMenuList(menus);
//   }, []);

//   useEffect(() => {
//     const id = parseInt(menuId, 10);
//     fetchItem(id);
//   }, [menuId]);

//   const fetchItem = async (id: number) => {
//     try {
//       const menuData = await fetchMenuById(id);
//       setData(menuData.menuItems.map((item: any) => item));
//     } catch (error) {
//       console.error("Error fetching menu item:", error);
//     }
//   };

//   useEffect(() => {
//     const menus = data.map((menu: MenuItem) => <MenuCard {...menu} />);
//     setMenuList(menus);
//   }, [data]);

//   return (
//     <div>
//       <h1 className="text-center text-3xl mb-4">Nos plats</h1>
//       {menuList.length > 0 ? (
//         <div className="grid md:grid-cols-2 lg:grid-cols-3 gap-4">
//           {menuList}
//         </div>
//       ) : (
//         <div>Loading...</div>
//       )}
//     </div>
//   );
// }
