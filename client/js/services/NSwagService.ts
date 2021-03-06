﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.2.5.0 (NJsonSchema v10.1.7.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export class LampuService {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    /**
     * @return Success
     */
    allLamp(): Promise<void> {
        let url_ = this.baseUrl + "/api/v1/lampu/all-lamp";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processAllLamp(_response);
        });
    }

    protected processAllLamp(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    insertLamp(body: LampuModel | undefined): Promise<ResponseModel> {
        let url_ = this.baseUrl + "/api/v1/lampu/insert";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processInsertLamp(_response);
        });
    }

    protected processInsertLamp(response: Response): Promise<ResponseModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <ResponseModel>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<ResponseModel>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    updateLamp(body: LampuModel | undefined): Promise<ResponseModel> {
        let url_ = this.baseUrl + "/api/v1/lampu/update";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processUpdateLamp(_response);
        });
    }

    protected processUpdateLamp(response: Response): Promise<ResponseModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <ResponseModel>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<ResponseModel>(<any>null);
    }

    /**
     * @param body (optional) 
     * @return Success
     */
    deleteLamp(body: LampuModel | undefined): Promise<ResponseModel> {
        let url_ = this.baseUrl + "/api/v1/lampu/delete";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(body);

        let options_ = <RequestInit>{
            body: content_,
            method: "DELETE",
            headers: {
                "Content-Type": "application/json",
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processDeleteLamp(_response);
        });
    }

    protected processDeleteLamp(response: Response): Promise<ResponseModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <ResponseModel>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<ResponseModel>(<any>null);
    }

    /**
     * @param idLamp (optional) 
     * @return Success
     */
    getSpesificLamp(idLamp: number | undefined): Promise<LampuModel> {
        let url_ = this.baseUrl + "/api/v1/lampu/specific-lamp?";
        if (idLamp === null)
            throw new Error("The parameter 'idLamp' cannot be null.");
        else if (idLamp !== undefined)
            url_ += "idLamp=" + encodeURIComponent("" + idLamp) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetSpesificLamp(_response);
        });
    }

    protected processGetSpesificLamp(response: Response): Promise<LampuModel> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <LampuModel>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<LampuModel>(<any>null);
    }

    /**
     * @param pageIndex (optional) 
     * @param itemPerPage (optional) 
     * @param filterByName (optional) 
     * @return Success
     */
    filterData(pageIndex: number | undefined, itemPerPage: number | undefined, filterByName: string | undefined): Promise<LampuModel[]> {
        let url_ = this.baseUrl + "/api/v1/lampu/filter-data?";
        if (pageIndex === null)
            throw new Error("The parameter 'pageIndex' cannot be null.");
        else if (pageIndex !== undefined)
            url_ += "pageIndex=" + encodeURIComponent("" + pageIndex) + "&"; 
        if (itemPerPage === null)
            throw new Error("The parameter 'itemPerPage' cannot be null.");
        else if (itemPerPage !== undefined)
            url_ += "itemPerPage=" + encodeURIComponent("" + itemPerPage) + "&"; 
        if (filterByName === null)
            throw new Error("The parameter 'filterByName' cannot be null.");
        else if (filterByName !== undefined)
            url_ += "filterByName=" + encodeURIComponent("" + filterByName) + "&"; 
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processFilterData(_response);
        });
    }

    protected processFilterData(response: Response): Promise<LampuModel[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <LampuModel[]>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<LampuModel[]>(<any>null);
    }

    /**
     * @return Success
     */
    totalData(): Promise<number> {
        let url_ = this.baseUrl + "/api/v1/lampu/total-data";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "text/plain"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processTotalData(_response);
        });
    }

    protected processTotalData(response: Response): Promise<number> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            result200 = _responseText === "" ? null : <number>JSON.parse(_responseText, this.jsonParseReviver);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<number>(<any>null);
    }
}

export interface LampuModel {
    idLampu?: number;
    namaLampu: string;
    stockLampu: number;
}

export interface ResponseModel {
    responseMessage?: string | undefined;
    status?: string | undefined;
}

export class ApiException extends Error {
    message: string;
    status: number; 
    response: string; 
    headers: { [key: string]: any; };
    result: any; 

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}