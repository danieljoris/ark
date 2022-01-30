from datetime import datetime
from typing import Any, Dict, Type
from uuid import UUID, uuid4

import pydantic
from beanie import Document, SaveChanges, before_event


class Entity(Document):
    created_at: datetime
    updated_at: datetime

    @before_event(SaveChanges)
    def update_timestamps(self):
        self.updated_at = datetime.utcnow()

    class Config:
        arbitrary_types_allowed = True
