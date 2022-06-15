export class Response<T>{

  public Data : Data<T> | undefined
}
export class Data<T> {
    public  IsSuccess : boolean = false;
    public  Result :T | undefined;
    public  Message : string = ""
}