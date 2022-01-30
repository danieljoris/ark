import beanie
from dependency_injector import containers, providers
from domain.entities.animal import Animal
from motor.motor_asyncio import AsyncIOMotorClient


class Container(containers.DeclarativeContainer):
    config = providers.Configuration()

    motor_client = providers.Singleton(
        AsyncIOMotorClient, host=config.connection_string
    )
