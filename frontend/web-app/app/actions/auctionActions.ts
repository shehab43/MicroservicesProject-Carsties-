'use server'

import { Auction, PageResult } from "../types/Index";

// export async function getData(pageNumber:number,pageSize:number):Promise<PageResult<Auction>> {
//     const res = await fetch(`http://localhost:6001/search?pageSize=${pageSize}&&pageNumber=${pageNumber}`);

export async function getData(url:string):Promise<PageResult<Auction>> {
    const res = await fetch(`http://localhost:6001/search?${url}`);
          if(!res.ok) throw new Error('Something went wrong')

            return res.json()
          
}