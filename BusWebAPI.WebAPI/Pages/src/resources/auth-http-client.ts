import { autoinject } from "aurelia-framework";
import { HttpClient } from "aurelia-fetch-client";
import { ExpireableLocalstorage } from "aleph1-aurelia-utilities";
import { getLogger, Logger } from "aurelia-logging";
import environment from "environment";

@autoinject()
export class AuthHttpClient extends HttpClient
{
	public logger: Logger;

	private authenticationKey: string = "AuthenticationInfo";
	private ticketExpirationMin: number = 999999;

	constructor()
	{
		super();
		this.logger = getLogger(this.constructor.name);

		this.configure(conf =>
		{
			conf.useStandardConfiguration()
				.withBaseUrl(environment.apiPrefix)
				.withInterceptor(
				{
					request: request =>
					{
						this.logger.info(`Requesting ${request.method} ${request.url}`);

						const authenticationInfoValue = ExpireableLocalstorage.getItem(this.authenticationKey);
						if(authenticationInfoValue)
						{
							request.headers.append(this.authenticationKey, authenticationInfoValue);
						}

						return request;
					},
					response: response =>
					{
						this.logger.info(`Response ${response.status} ${response.url}`);

						const authenticationInfoValue = response.headers.get(this.authenticationKey);
						if(authenticationInfoValue)
						{
							ExpireableLocalstorage.setItem(this.authenticationKey, authenticationInfoValue, this.ticketExpirationMin);
						}
						return response;
					},
					responseError: errorResponse =>
					{
						// Network Error
						if(errorResponse instanceof TypeError)
						{
							throw errorResponse;
						}

						// Any other Error 
						return errorResponse.json().then(json => ({ messageForUser: json.ExceptionMessage || json.Message || json, error: json }))
							.catch(() => errorResponse.text().then(text => ({ messageForUser: "התרחשה שגיאה", error: text })))
							.then(customErrorObj =>
							{
								throw errorResponse;
							});
					}
				});
		});
	}


	public queryString(baseUrl: string, parameters: any): string
	{
		const query: string = Object.keys(parameters)
			.filter(key => parameters[key])
			.map(key => `${key}=${parameters[key]}`)
			.join("&");
		return `${baseUrl}?${query}`;
	}
}
