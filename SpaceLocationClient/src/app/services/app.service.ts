import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from 'src/services/api.service';
import { environment } from 'src/environments/environment';
import {Response} from '../../models/response';
import {Location} from  '../../app/models/location';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  public location$ : Observable<Response<Location>> | undefined; 
  public locations$ : Observable<Response<Array<Location>>> | undefined;
  constructor(private apiService : ApiService) {
  }
    
  public getCurrentLocation() : Observable<Response<Location>>{
    if(this.location$)
    return this.location$ ;
    this.location$  = this.apiService.get("/Locations/Current",{}).pipe((response : any)=>{
      return response;}
    );
    return this.location$ ;
  }
  public getLocations() : Observable<Response<Array<Location>>>{
    if(this.locations$){
        return this.locations$;
    }
    this.locations$  = this.apiService.get("/Locations",{}).pipe((response : any)=>{
      return response;}
    );
    return this.locations$ ;
  }
  public saveLocation(model : Location): Promise<boolean>{
    return new Promise((resolve)=>{
    this.apiService.post("/Locations/Save",model).subscribe((response : any)=>{
      if(response.Data?.IsSuccess){
        return resolve(true);
      }else{
        return resolve(false);
      }
    });
  })
  }
  
  
     
}
