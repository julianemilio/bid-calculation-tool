﻿namespace Application.Abstractions;

public interface IQueryHandler<TQuery, TResult>
{
    TResult Handle(TQuery query);
}