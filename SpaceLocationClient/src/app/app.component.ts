import { Component } from '@angular/core';
import { AppService } from './services/app.service';
import {Response} from '../models/response';
import {Location} from '../app/models/location';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  public currentLocation : Location  = new Location();
  closeResult: string | undefined; 
  myNotes : string | undefined;
  public locations : Array<Location>  = new Array<Location>();
 
  getLocations(){
    this.appService.getLocations().subscribe((response  : Response<Array<Location>>)=>{
    if(response?.Data?.IsSuccess){
      this.locations = response?.Data?.Result ?? [];
    }
    });
  }
 
  constructor(private appService : AppService,
    private modalService: NgbModal){
  }
  open(content : any) {  
    this.getCurrentLocation().then((result : Location) =>{
      this.currentLocation.Latitude = result.Latitude;
      this.currentLocation.Longitude = result.Longitude;
      this.currentLocation.CurrentTime =result.CurrentTime;
    })
       this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
       this.currentLocation.Notes = result;
       this.saveLocation();


      }, (reason) => {  
      });  
      }
 
  
  getCurrentLocation():Promise<Location>{
    return new Promise<Location>((resolve)=>{
      return this.appService.getCurrentLocation().subscribe((response : Response<Location>)=>{
        if(response?.Data?.IsSuccess){
          let r : Location = response?.Data?.Result ?? new Location();
          resolve(r);
        }
    })
  });

 
}
saveLocation(){
  this.appService.saveLocation(this.currentLocation).then((response)=>{
    this.getLocations();
  })
}
}
