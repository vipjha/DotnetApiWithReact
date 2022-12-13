import { useState, useEffect } from "react";
import { Product } from "../../app/models/product";
import ProductList from "./ProductLsit";

/* interface Props{
  products: Product[];
  addProduct:()=>void;
} */

export default function Catalog(){
  const [products, setProducts]= useState<Product[]> ([]);

  useEffect(()=>{
    fetch('https://localhost:7120/api/Products')
    .then(response =>response.json())
    .then(data=>setProducts(data))
  },[])

    return(
        <>
        <ProductList products ={products} />
       
        </>
    )
} 