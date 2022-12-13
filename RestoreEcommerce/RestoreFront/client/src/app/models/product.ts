export interface Product{
    id: number;
    name: string;
    discription: string;
    price: number;
    pictureUrl: string;
    type?: string;
    brand: string;
    quantityInStock?: number;
}