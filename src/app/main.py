import sys

from beanie import init_beanie
from dependency_injector.wiring import Provide, inject
from domain.entities.animal import Animal
from domain.entities.audit import AuditRecord
from domain.entities.castration import Castration
from domain.entities.veterinary_clinic import VeterinaryClinic
from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from fastapi_pagination import add_pagination
from motor.motor_asyncio import AsyncIOMotorClient

import app.routers.audit as audit_router_module
from app.dependencies import Container
from app.routers.routers import api_router

app = FastAPI()


@inject
async def configure_beanie(
    motor_client: AsyncIOMotorClient = Provide[Container.motor_client],
):
    await init_beanie(
        database=motor_client.db_name,
        document_models=[Animal, Castration, VeterinaryClinic, AuditRecord],
    )


@app.on_event("startup")
async def app_init():

    # Dependency injection
    container = Container()
    container.config.connection_string.from_value(
        "mongodb://admin:admin@localhost:27020/ark?authSource=admin&readPreference=primary&ssl=false"
    )

    container.init_resources()
    container.wire(modules=[sys.modules[__name__], audit_router_module])

    app.container = container

    # Database configuration
    await configure_beanie()

    # Routes config
    app.include_router(api_router)

    # Middlewares
    app.add_middleware(
        CORSMiddleware,
        allow_origins=["*"],
        allow_credentials=True,
        allow_methods=["*"],
        allow_headers=["*"],
    )
    add_pagination(app)
