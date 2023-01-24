import axios, { AxiosError, AxiosResponse } from "axios";
import { toast } from "react-toastify";


axios.defaults.baseURL='https://localhost:7120/api/';

const responseBody = (response:AxiosResponse)=>response.data;
//const data = (response:AxiosError)=> response.isAxiosError;


axios.interceptors.response.use(response=>{
    return response
},(error:AxiosError)=>{
    console.log(responseBody)
//console.log('caught by interceptor');
const{data, status}=error.response!;
switch (status) {
    case 400:
        /* if(data.errors){
            const modelStateErrors: string[]=[];
            for(const key in data.errors){
                if(data.error[key]){
                    modelStateErrors.push(data.errors[key])
                }
            }
            throw modelStateErrors.flat();
        } */
        toast.error("This is 400 error")
        break;
    case 401:
        toast.error("This is 401 error")
        break;
    case 500:
        toast.error("This is 500 error")
        break;
    default:
        break;
}
//console.log(data,'safsadfasd')
return Promise.reject(error.response);
})

const requests ={
    get:(url:string)=>axios.get(url).then(responseBody),
    post:(url:string, body:{})=>axios.post(url, body).then(responseBody),
    put:(url:string, body:{})=>axios.put(url, body).then(responseBody),
    delete:(url:string)=>axios.delete(url).then(responseBody),
}

const Catalog={
    list:()=>requests.get('products'),
    details:(id:number)=>requests.get(`products/${id}`)
   /*  list: (params: URLSearchParams) => requests.get('products', params),
    details: (id: number) => requests.get(`products/${id}`), */
}

const TestErrors={
    get400Error:()=>requests.get('buggy/bad-request'),
    get401Error:()=>requests.get('buggy/unauthorised'),
    get404Error:()=>requests.get('buggy/not-found'),
    get500Error:()=>requests.get('buggy/server-error'),
    getValidationError:()=>requests.get('buggy/validation-error')
}

const agent ={
    Catalog,
    TestErrors
}

export default agent;
/* 
function responseBodyFn(response:AxiosResponse){
    return response.data;
} 
*/