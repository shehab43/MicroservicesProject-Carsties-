export type PageResult<T> = {
    results: T[];
    pageCount: number;
    totalCount: number;
  };
  export type Auction = {
    id: number;
  
    reservePrice: number;
  
    seller: string;
  
    winner?: number;
  
    soldAmount: number;
  
    currentHighBid: number;
  
    createdAt: string;
  
    updatedAt: string;
  
    auctionEnd: string;
  
    status: string;
  
    make: string;
  
    model: string;
  
    year: string;
  
    color: string;
  
    mileage: string;
  
    imageUrl: string;
  };
  