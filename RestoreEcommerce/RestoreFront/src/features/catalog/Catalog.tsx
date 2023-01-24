import { useState, useEffect } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductLsit";
import agent from "../../app/api/agent";

/* interface Props{
  products: Product[];
  addProduct:()=>void;
} */

export default function Catalog(){
  const [products, setProducts]= useState<Product[]> ([]);

  useEffect(()=>{
    agent.Catalog.list().then(products=>setProducts(products))
  },[])

    return(
        <>
        <ProductList products ={products} />
        </>
    )
} 