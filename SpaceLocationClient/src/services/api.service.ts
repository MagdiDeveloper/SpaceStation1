import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { environment } from 'src/environments/environment';
import {Response} from '../models/response';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private httpClient : HttpClient) { }
  public get<TRequest,TResponse>(url : string, body : TRequest): Observable<Response<TResponse>>{
    let baseUrl : string = environment.apiUrl;
    let  apiUrl : string = baseUrl+url;
    return this.httpClient.get<Response<TResponse>>(apiUrl,body);
  }
  public post<TRequest,TResponse>(url : string, body : TRequest) : Observable<Response<TResponse>>{
    let baseUrl : string = environment.apiUrl;
    let  apiUrl : string = baseUrl+url;
    return this.httpClient.post<Response<TResponse>>(apiUrl,body);
  }
}
