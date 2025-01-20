import Listings from "./auctions/Listings";

export default function Home() {
  console.log('Server Componet')

  return (
    
    <div className="text-3xl font-semibold">
      <Listings/>
    </div>
  );
}
