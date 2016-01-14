package services;

import dto.Couple;

import javax.ws.rs.*;
import javax.ws.rs.core.Response;

/**
 * Created by artur.vahanyan on 1/13/2016.
 */
@Path("/calc")
public class CalculatorService {

    @POST
    @Path("/add")
    @Consumes("application/json")
    public Response addNumbers(Couple digits){
        return Response.status(200).entity(String.valueOf(digits.getX() + digits.getY())).build();
    }

    @POST
    @Path("/divide")
    @Consumes("application/json")
    public Response divideNummbers(Couple digits){
        if(digits.getY() == 0){
            return Response.status(501).build();
        }
        return Response.status(200).entity(String.valueOf(digits.getX() / digits.getY())).build();
    }

    @POST
    @Path("/sub")
    @Consumes("application/json")
    public Response subNumbers(Couple digits){
        return Response.status(200).entity(String.valueOf(digits.getX() - digits.getY())).build();
    }

    @POST
    @Path("/concatenation")
    @Consumes("application/json")
    public Response concatNumbers(Couple digits){
        return Response.status(200).entity(String.valueOf(digits.getX() * digits.getY())).build();
    }
}